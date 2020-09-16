using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP3_Chats.Models;
using TP3_Chats.Database;

namespace TP3_Chats.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            List<Chat> ListeChats = FakeDB.Instance.Chats;
            return View(ListeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            List<Chat> ListeChats = FakeDB.Instance.Chats;
            Chat chatToDetails = ListeChats.Where(x => x.Id == id).FirstOrDefault();

            return View(chatToDetails);
        }


        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {

            List<Chat> ListeChats = FakeDB.Instance.Chats;
            Chat chatToRemove = ListeChats.Where(x => x.Id == id).FirstOrDefault();
            
            if (chatToRemove == null)
            {
                return RedirectToAction("Index");
            } else
            {
                return View(chatToRemove);
            }

           
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                List<Chat> ListeChats = FakeDB.Instance.Chats;
                Chat chatToRemove = ListeChats.Where(x => x.Id == id).FirstOrDefault();

                if (chatToRemove != null)
                {
                    ListeChats.Remove(chatToRemove);
                }
            }
            catch
            {
                return View(id);
            }
            return RedirectToAction("Index");
        }
    }
}
