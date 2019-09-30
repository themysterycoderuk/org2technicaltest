using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebSolution.Models;

namespace WebSolution.Controllers
{
    public abstract class controllerBase : Controller
    {
        protected void addHomeToBreadCrumb()
        {
            addBreadCrumb("Home", "Index", "Home");
        }

        protected void addDocumentToBreadCrumb()
        {
            addBreadCrumb("Home", "Index", "Home");
            addBreadCrumb("Document", "Index", "Document");
        }

        protected void addBreadCrumb(string label, string action, string controller)
        {
            IList<Breadcrumb> crumbs;

            if (ViewBag.Breadcrumbs == null)
            {
                crumbs = new List<Breadcrumb>();
                ViewBag.Breadcrumbs = crumbs;
            }
            else
            {
                crumbs = (List<Breadcrumb>)ViewBag.Breadcrumbs;
            }

            crumbs.Add(new Breadcrumb()
            {
                Label = label,
                Action = action,
                Controller = controller
            });
        }
    }
}