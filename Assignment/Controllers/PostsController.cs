using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment.Data;
using Assignment.Models;
using Microsoft.Extensions.Hosting;
using Assignment.Services.Interfaces;

namespace Assignment.Controllers
{
    public class PostsController : Controller
    {
        private readonly DbPosts context;
        private readonly IPostService postService;

        public PostsController(DbPosts context, IPostService postService)
        {
            this.context = context;
            this.postService = postService;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            if (context.Post != null)
            {
                var posts = from p in context.Post
                            select p;

                return View(await posts.OrderByDescending(p => p.DateAdded).ToListAsync());
            }

            else
            {
                return Problem("Entity set 'DbPosts.Post' is null.");
            }
        }

        public async Task<IActionResult> IndexFiltered(string comment)
        {
            var posts = from p in context.Post
                       select p;

            if (comment == null || context.Post == null)
            {
                return NotFound();
            }

            if (!String.IsNullOrEmpty(comment))
            {
                posts = posts.Where(p => p.Comment == comment);
            }

            return View(await posts.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Post == null)
            {
                return NotFound();
            }

            var post = await context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,AuthorName,Email,Comment,DateAdded")] Post post)
        {
            if (ModelState.IsValid)
            {
                await postService.AddPost(post);

                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Post == null)
            {
                return NotFound();
            }

            var post = await context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,AuthorName,Email,Comment,DateAdded")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await postService.EditPost(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Post == null)
            {
                return NotFound();
            }

            var post = await context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (context.Post == null)
            {
                return Problem("Entity set 'DbPosts.Post'  is null.");
            }

            await postService.DeletePost(id);

            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return (context.Post?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
