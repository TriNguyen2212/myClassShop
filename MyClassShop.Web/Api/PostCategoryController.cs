using MyClassShop.Model.Models;
using MyClassShop.Service;
using MyClassShop.Web.Infratructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyClassShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) :
            base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid ==false)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var ListCategory = _postCategoryService.GetAll();
                    response = request.CreateResponse(HttpStatusCode.OK, ListCategory);
                }

                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;

                 if (ModelState.IsValid)
                 {
                     request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     var Category = _postCategoryService.Add(postCategory);
                     _postCategoryService.Save();

                     response = request.CreateResponse(HttpStatusCode.Created, Category);
                 }

                 return response;
             });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
    }
}