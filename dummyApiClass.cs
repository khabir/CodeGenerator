private const string _routePrefix = "api/Dummy";
private const string _getEndpointName = $"{_routePrefix}/{nameof(Get)}";

public static void MapEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
{
	RouteGroupBuilder routeGroupBuilder = endpointRouteBuilder.MapGroup(_routePrefix);

	routeGroupBuilder.MapPost("/", Create);
	routeGroupBuilder.MapPut("/", Update);
	routeGroupBuilder.MapDelete("/", Delete);
	routeGroupBuilder.MapGet("/", Get).WithName(_getEndpointName);
}

private static async Task<Results<CreatedAtRoute, BadRequest<string>, InternalServerError>> Create([FromBody] CreateDummyRequest request, IDummyFeatures dummyFeatures, IMapper mapper)
{
	DummyModel dummyModel = mapper.Map<DummyModel>(request);

	CreateResult result = await dummyFeatures.Create(dummyModel);

	return result.GenerateCreateResponse(getEndpointName: _getEndpointName, routeValues: new
	{
		DummyId = dummyModel.DummyId
	});
}

private static async Task<Results<NoContent, NotFound, BadRequest<string>, InternalServerError>> Update([FromBody] UpdateDummyRequest request, IDummyFeatures dummyFeatures, IMapper mapper)
{
	DummyModel dummyModel = mapper.Map<DummyModel>(request);

	UpdateResult result = await dummyFeatures.Update(dummyModel);

	return result.GenerateUpdateResponse();
}

private static async Task<Results<NoContent, NotFound, BadRequest<string>, InternalServerError>> Delete(Ulid dummyId, IDummyFeatures dummyFeatures)
{
	DeleteResult result = await dummyFeatures.Delete(dummyId);

	return result.GenerateDeleteResponse();
}

public static async Task<Results<Ok<GetDummyResponse>, NotFound, BadRequest<string>, InternalServerError>> Get(Ulid dummyId, IDummyFeatures dummyFeatures)
{
	GetResult<GetDummyResponse> result = await dummyFeatures.Get(dummyId);

	return result.GenerateGetResponse();
}