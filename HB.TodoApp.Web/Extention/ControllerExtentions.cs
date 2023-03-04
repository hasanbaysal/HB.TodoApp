using HB.TodoApp.Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;

namespace HB.TodoApp.Web.Extention
{
    public static class ControllerExtentions
    {
        //post forms
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response,string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
               return controller.NotFound();
            }
            if (response.ResponseType == ResponseType.ValidationError)
            {
                response.ValidationErrors.ForEach(x => controller.ModelState.AddModelError(x.ProppertyName, x.ErrorMessage));
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName);
        }
        //update get
        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            return controller.View(response.Data);

        }

        //delete
        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName)
        {
            if(response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionName);
        }
        

    }
}
