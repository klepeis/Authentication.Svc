namespace Authentication.Svc.Services;

public interface ITokenGenerationService
{
    string CreateAccessToken();
    string CreateRefreshToken();
}