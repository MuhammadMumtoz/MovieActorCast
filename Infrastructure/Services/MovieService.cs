using AutoMapper;
using Infrastructure.Context;
using Domain.Wrapper;
using Domain.Entities;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Domain.Filters;
using System.Linq;
using System.Net;

namespace Infrastructure.Services;
public class MovieService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public MovieService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginationResponse<List<GetActorDto>>> GetAllActors()
    {
        var list = await _context.Actors.ToListAsync();
        var response = _mapper.Map<List<GetActorDto>>(list);
        var totalRecords = _context.Actors.Count();
        return new PaginationResponse<List<GetActorDto>>(response, totalRecords, 10, 1);
    }
    public async Task<PaginationResponse<List<GetCastDto>>> GetAllCasts()
    {
        var list = await _context.Casts.ToListAsync();
        var response = _mapper.Map<List<GetCastDto>>(list);
        var totalRecords = _context.Casts.Count();
        return new PaginationResponse<List<GetCastDto>>(response, totalRecords, 10, 1);
    }
    public async Task<PaginationResponse<List<GetCastMovieDto>>> GetAllCasts2()
    {
        // var list = await _context.Casts.ToListAsync();
        // var response = _mapper.Map<List<GetCastDto>>(list);
        var list = await (from ct in _context.Casts
                          join mv in _context.Movies on ct.MovieId equals mv.MovieId
                          join ac in _context.Actors on ct.ActorId equals ac.ActorId
                          select new GetCastMovieDto()
                          {
                              CastId = ct.CastId,
                              MovieId = mv.MovieId,
                              MovieTitle = mv.Title,
                              ActorId = ac.ActorId,
                              ActorFullname = ac.Fullname
                          }).ToListAsync();
        var totalRecords = _context.Casts.Count();
        return new PaginationResponse<List<GetCastMovieDto>>(list, totalRecords, 10, 1);
    }
    public async Task<PaginationResponse<List<GetCategoryDto>>> GetAllCategories()
    {
        var list = await _context.Categories.ToListAsync();
        var response = _mapper.Map<List<GetCategoryDto>>(list);
        var totalRecords = _context.Casts.Count();
        return new PaginationResponse<List<GetCategoryDto>>(response, totalRecords, 10, 1);
    }
    public async Task<PaginationResponse<List<GetMovieDto>>> GetAllMovies(MovieFilter filter)
    {
        var query = _context.Movies.AsQueryable();
        if (filter.Name == null) query = query.Where(x => x.Title != null);
        if (filter.Name != null) query = query.Where(x => x.Title.Contains(filter.Name));
        if (filter.CategoryId != null) query = query.Where(x => x.CategoryId == filter.CategoryId);
        var filtered = query.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();
        var response = _mapper.Map<List<GetMovieDto>>(filtered);
        var totalRecords = await _context.Movies.CountAsync();
        return new PaginationResponse<List<GetMovieDto>>(response, totalRecords, filter.PageSize, filter.PageNumber);
    }
    public async Task<PaginationResponse<List<GetCategoryDto>>> GetAllCategories(CategoryFilter filter)
    {
        var query = _context.Categories.AsQueryable();
        if (filter.Name != null) query = query.Where(x => x.Title.Contains(filter.Name));
        var filtered = query.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();
        var response = _mapper.Map<List<GetCategoryDto>>(filtered);
        var totalRecords = await _context.Categories.CountAsync();
        return new PaginationResponse<List<GetCategoryDto>>(response, totalRecords, filter.PageSize, filter.PageNumber);
    }

    public async Task<Response<GetMovieDto>> GetMovieById(int id)
    {
        var customer = await _context.Movies.FirstOrDefaultAsync(x => x.MovieId == id);
        if (customer == null)
        {
            return new Response<GetMovieDto>(System.Net.HttpStatusCode.NotFound, "Movie not found!");
        }
        return new Response<GetMovieDto>(_mapper.Map<GetMovieDto>(customer));
    }
    public async Task<Response<AddMovieDto>> InsertMovie(AddMovieDto addMovieDto)
    {
        try
        {
            var movie = _mapper.Map<Movie>(addMovieDto);
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return new Response<AddMovieDto>(addMovieDto);
        }
        catch
        {
            return new Response<AddMovieDto>(System.Net.HttpStatusCode.InternalServerError, "Internal server error.");
        }
    }
    public async Task<Response<AddMovieDto>> UpdateMovie(AddMovieDto addMovieDto)
    {
        try
        {
            var movie = await _context.Movies.FindAsync(addMovieDto.MovieId);
            movie.Title = addMovieDto.Title;
            movie.MovieYear = addMovieDto.MovieYear;
            movie.CategoryId = addMovieDto.CategoryId;
            await _context.SaveChangesAsync();
            return new Response<AddMovieDto>(addMovieDto);
        }
        catch
        {
            return new Response<AddMovieDto>(System.Net.HttpStatusCode.InternalServerError, "Internal server error.");
        }
    }
    public async Task<Response<string>> DeleteMovie(int id){
        var movie = await _context.Movies.FindAsync(id);
        _context.Remove(movie);
        var response = await _context.SaveChangesAsync();
        if (response > 0) {
            return new Response<string>("Movie successfully deleted");
        }
        else{
            return new Response<string>(HttpStatusCode.BadRequest,"Movie not found");
        }
    }
}