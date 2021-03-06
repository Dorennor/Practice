﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PracticeShop.Models;
using PracticeShop.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PracticeShop.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContextDB _db;
        //private readonly IWebHostEnvironment _appEnvironment;
        private readonly ApplicationContext _userDb;

        public StoreController(StoreContextDB context, /*IWebHostEnvironment appEnvironment,*/ ApplicationContext userContext)
        {
            _db = context;
            //_appEnvironment = appEnvironment;
            _userDb = userContext;
        }

        [HttpGet]
        public IActionResult ShowLibrary() => View(_userGameList);

        [HttpGet]
        public IActionResult GamesList() => View(_db.Games.OrderBy(g => g.Name).ToList());

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddGame() => View();

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddGame(Game model)
        {
            if (!CheckStore(model))
            {
                _db.Games.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else return Content("ERROR");
        }

        [HttpPost]
        public IActionResult AddToLibrary(int id) => View("AddToLibrary", AddGameToLibrary(id));

        [HttpPost]
        public IActionResult BuyGame(int id) => View("BuyGame", AddGameToLibrary(id));

        private string AddGameToLibrary(int id)
        {
            if (!IsUserHasLibrary)
            {
                CreateLibraryWithGame(id);
            }
            else
            {
                if (CheckGame(id))
                {
                    return "Игра уже находится в Вашей библиотеке!";
                }

                Write(id);
            }

            return "Игра была добавлена в Вашу библиотеку!";
        }

        private void Write(int id)
        {
            List<Game> games;
            if (_libraryList.First().GamesID == "")
            {
                games = new List<Game>();
                games.Add(_db.Games.Find(id));
                _libraryList.First().GamesID = JsonSerializer.Serialize(games);
                _db.SaveChanges();
            }
            else
            {
                games = JsonSerializer.Deserialize<List<Game>>(_libraryList.First().GamesID);
                games.Add(_db.Games.Find(id));
                _libraryList.First().GamesID = JsonSerializer.Serialize(games);
                _db.SaveChanges();
            }
        }

        private void Delete(int id)
        {
            var games = JsonSerializer.Deserialize<List<Game>>(_libraryList.First().GamesID);
            if (games.Count > 1)
            {
                games.Remove(_db.Games.Find(id));
                _libraryList.First().GamesID = JsonSerializer.Serialize(games);
                _db.SaveChanges();
            }
            else
            {
                _libraryList.First().GamesID = "";
                _db.SaveChanges();
            }
        }

        private bool CheckGame(int id)
        {
            if (_userGameList == null) return false;
            return _userGameList.Where(g => g.ID == id).ToList().Count > 0;
        }

        private bool IsUserHasLibrary => _libraryList.Count >= 1;

        private List<Game> _userGameList
        {
            get
            {
                try
                {
                    return JsonSerializer.Deserialize<List<Game>>(_libraryList.Last().GamesID);
                }
                catch
                {
                    return null;
                }
            }
        }

        private bool CheckStore(Game model)
        {
            var result = _db.Games.Where(g => g.Name == model.Name).ToList();
            if (result.Count > 0) return true;
            else return false;
        }

        private List<Library> _libraryList => _db.Libraries.Where(l => l.UserID == CurrentUser.Id).ToList();

        private void CreateLibraryWithGame(int id)
        {
            var games = new List<Game> { _db.Games.Find(id) };

            _db.Libraries.Add(new Library(CurrentUser.Id, JsonSerializer.Serialize(games)));
            _db.SaveChanges();
        }

        public IActionResult DeleteGame() => View(_db.Games.OrderBy(g => g.Name));

        [HttpPost]
        public IActionResult DeleteGame(int id)
        {
            _db.Games.Remove(_db.Games.Where(g => g.ID == id).First());
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditGameView() => View(_db.Games.OrderBy(g => g.Name));

        [HttpGet]
        public IActionResult EditGame(int id)
        {
            Game game = _db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            EditGameViewModel model = new EditGameViewModel { Name = game.Name, Genre = game.Genre, Publisher = game.Publisher, Price = game.Price };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditGame(EditGameViewModel model)
        {
            Game game = _db.Games.Find(model.Id);
            if (ModelState.IsValid)
            {
                if (game != null)
                {
                    game.Name = model.Name;
                    game.Genre = model.Genre;
                    game.Publisher = model.Publisher;
                    game.Price = model.Price;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DeleteGameFromLibrary(int id)
        {
            Delete(id);
            return RedirectToAction("Index", "Home");
        }

        public User CurrentUser
        {
            get
            {
                return _userDb.Users.Where(u => u.UserName == User.Identity.Name).First();
            }
        }
    }
}