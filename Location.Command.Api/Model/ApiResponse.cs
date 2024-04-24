namespace Location.Command.Api.Model;

public sealed record ApiResponse<T>(T? Data, string? Erro = null);