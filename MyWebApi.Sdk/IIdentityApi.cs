using System;
using System.Collections.Generic;
using Refit;
using System.Text;
using System.Threading.Tasks;
using MyWebApi.Contracts.V1.Responses;
using MyWebApi.Contracts.V1.Requests;

namespace MyWebApi.Sdk
{
    public interface IIdentityApi
    {
        [Post("/api/v1/identity/register")]
        Task<ApiResponse<AuthSuccessResponse>> RegisterAsync([Body]UserRegistrationRequest registrationRequest);

        [Post("/api/v1/identity/login")]
        Task<ApiResponse<AuthSuccessResponse>> LoginAsync([Body]UserLoginRequest userLoginRequest);

        [Post("/api/v1/identity/refresh")]
        Task<ApiResponse<AuthSuccessResponse>> RefreshAsync([Body]RefreshTokenRequest refreshTokenRequest);
    }
}
