using System.Collections.Generic;
using System.Web.Mvc;
using ReactSandbox.Models;

namespace ReactSandbox.Controllers
{
    [Route("comments")]
    public class CommentsController : Controller
    {
        private static readonly IList<CommentModel> _comments;

        static CommentsController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!"
                },
                new CommentModel
                {
                    Author = "Pete Hunt",
                    Text = "This is one comment"
                },
                new CommentModel
                {
                    Author = "Jordan Walke",
                    Text = "This is *another* comment"
                },
            };
        }

        [Route("")]
        public ActionResult Index()
        {
            return View(_comments);
        }

        [HttpPost]
        [Route("add-comment")]
        public ActionResult AddComment(CommentModel model)
        {
            _comments.Add(model);
            return Content("Success");
        }

        [Route("all")]
        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }
    }
}