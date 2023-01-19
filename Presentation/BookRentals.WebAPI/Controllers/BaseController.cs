using BookRentals.Common.Services;
using BookRentals.Common.Services.Helper;
using Microsoft.AspNetCore.Mvc;

namespace BookRentals.WebAPI.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private IServiceResponseHelper ServiceResponseHelper => this.HttpContext.RequestServices.GetService<IServiceResponseHelper>();

        protected ServiceResponse Success()
        {
            return this.ServiceResponseHelper.SetSuccess();
        }

        protected ServiceResponse<T> Success<T>(T data)
        {
            return this.ServiceResponseHelper.SetSuccess(data);
        }

        protected ServiceResponse<T> Error<T>(T data, string errorMessage, int statusCode = StatusCodes.Status500InternalServerError)
        {
            return this.ServiceResponseHelper.SetError(data, errorMessage, statusCode);
        }

        protected ServiceResponse Error(string errorMessage, int statusCode = StatusCodes.Status500InternalServerError)
        {
            return this.ServiceResponseHelper.SetError(errorMessage, statusCode);
        }

        protected ServiceResponse Error(ErrorInfo error)
        {
            return this.ServiceResponseHelper.SetError(error);
        }
    }
}
