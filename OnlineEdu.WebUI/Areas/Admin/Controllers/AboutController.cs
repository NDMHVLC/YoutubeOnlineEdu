﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            
            var values = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _client.DeleteAsync($"abouts/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _client.PostAsJsonAsync("abouts",createAboutDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateAboutDto>($"abouts/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _client.PutAsJsonAsync("abouts",updateAboutDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
