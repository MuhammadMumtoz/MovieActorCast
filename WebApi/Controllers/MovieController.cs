using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Filters;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController
{
    private readonly MovieService _movieService;

    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }
    [HttpGet("GetAllActors")]
    public async Task<Response<List<GetActorDto>>> GetAllActors()
    {
        return await _movieService.GetAllActors();
    }
    [HttpGet("GetAllCasts")]
    public async Task<Response<List<GetCastDto>>> GetAllCasts()
    {
        return await _movieService.GetAllCasts();
    }
    [HttpGet("GetAllCasts2")]
    public async Task<Response<List<GetCastMovieDto>>> GetAllCasts2()
    {
        return await _movieService.GetAllCasts2();
    }
    [HttpGet("GetAllCategories")]
    public async Task<Response<List<GetCategoryDto>>> GetAllCategories()
    {
        return await _movieService.GetAllCategories();
    }
    [HttpGet("GetAllMoviesWithFiltet")]
    public async Task<PaginationResponse<List<GetMovieDto>>> GetAllMovies([FromQuery]MovieFilter filter)
    {
        return await _movieService.GetAllMovies(filter);
    }
    [HttpGet("GetAllCategoriesWithFilter")]
    public async Task<PaginationResponse<List<GetCategoryDto>>> GetAllCategories([FromQuery]CategoryFilter filter)
    {
        return await _movieService.GetAllCategories(filter);
    }
    [HttpGet("GetMovieById")]
    public async Task<Response<GetMovieDto>> GetMovieById(int id){
        return await _movieService.GetMovieById(id);
    }
    [HttpPost("InsertMovie")]
    public async Task<Response<AddMovieDto>> InsertMovie(AddMovieDto addMovieDto){
        return await _movieService.InsertMovie(addMovieDto);
    }
    [HttpPut("UpdateMovie")]
    public async Task<Response<AddMovieDto>> UpdateMovie(AddMovieDto addMovieDto){
        return await _movieService.UpdateMovie(addMovieDto);
    }
    [HttpDelete("DeleteMovie")]
    public async Task<Response<string>> DeleteMovie(int id){
        return await _movieService.DeleteMovie(id);
    }
}
