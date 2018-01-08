using MvcTreeView.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MvcTreeView.Controllers
{
    [RoutePrefix("jstree")]
    public class JsTreeAPIController : ApiController
    {
        [HttpGet]
        [Route("gettreenodes")]
        public IHttpActionResult GetTreeNodes()
        {
            List<G_JSTree> G_JSTreeArray = new List<G_JSTree>();

            G_JSTree _G_JSTree = new G_JSTree();
            _G_JSTree.data = "x1";
            _G_JSTree.state = "closed";
            _G_JSTree.IdServerUse = 10;
            _G_JSTree.children = null;
            _G_JSTree.attr = new G_JsTreeAttribute { id = "10", selected = false };
            G_JSTreeArray.Add(_G_JSTree);

            G_JSTree _G_JSTree2 = new G_JSTree();
            var children =
                new G_JSTree[]
                {
                new G_JSTree { data = "x1-11", attr = new G_JsTreeAttribute { id = "201" } },
                new G_JSTree { data = "x1-12", attr = new G_JsTreeAttribute { id = "202" } },
                new G_JSTree { data = "x1-13", attr = new G_JsTreeAttribute { id = "203" } },
                new G_JSTree { data = "x1-14", attr = new G_JsTreeAttribute { id = "204" } },
                };
            _G_JSTree2.data = "x2";
            _G_JSTree2.IdServerUse = 20;
            _G_JSTree2.state = "closed";
            _G_JSTree2.children = children;
            _G_JSTree2.attr = new G_JsTreeAttribute { id = "20", selected = true };
            G_JSTreeArray.Add(_G_JSTree2);

            G_JSTree _G_JSTree3 = new G_JSTree();
            var children2 =
                new G_JSTree[]
                {
                new G_JSTree { data = "x2-11", attr = new G_JsTreeAttribute { id = "301" } },
                new G_JSTree { data = "x2-12", attr = new G_JsTreeAttribute { id = "302" },
                children = new G_JSTree[]{new G_JSTree{data = "x2-21", attr = new G_JsTreeAttribute { id = "3011" }}} },
                new G_JSTree { data = "x2-13", attr = new G_JsTreeAttribute { id = "303" } },
                new G_JSTree { data = "x2-14", attr = new G_JsTreeAttribute { id = "304" } },
                };
            _G_JSTree3.data = "x3";
            _G_JSTree3.state = "closed";
            _G_JSTree3.IdServerUse = 30;
            _G_JSTree3.children = children2;
            _G_JSTree3.attr = new G_JsTreeAttribute { id = "30", selected = true };
            G_JSTreeArray.Add(_G_JSTree3);
            return Json(G_JSTreeArray);
        }


        [HttpGet]
        [Route("getnodes")]
        public IHttpActionResult getnodes()
        {
            using (TextReader fileReader = File.OpenText(
                    Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath,
                    "json", "data.json")))
            {
                List<RootObject> obj = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<RootObject>>(fileReader.ReadToEnd());
                return Ok(obj);
            }

        }
    }

    public class State
    {
        public bool opened { get; set; }
        public bool selected { get; set; }
    }

    public class Child2
    {
        public string text { get; set; }
        public string id { get; set; }
    }

    public class Child
    {
        public string text { get; set; }
        public string id { get; set; }
        public List<Child2> children { get; set; }
    }

    public class RootObject
    {
        public string text { get; set; }
        public State state { get; set; }
        public List<Child> children { get; set; }
    }
}
