private const string _routePrefix = "api/Customer";
private const string _getEndpointName = $"{_routePrefix}/{nameof(Get)}";

public static void MapEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
{
	RouteGroupBuilder routeGroupBuilder = endpointRouteBuilder.MapGroup(_routePrefix);

	routeGroupBuilder.MapPost("/", Create);
	routeGroupBuilder.MapPut("/", Update);
	routeGroupBuilder.MapDelete("/", Delete);
	routeGroupBuilder.MapGet("/", Get).WithName(_getEndpointName);
}

private static async Task<Results<CreatedAtRoute, BadRequest<string>, InternalServerError>> Create([FromBody] CreateCustomerRequest request, ICustomerFeatures customerFeatures, IMapper mapper)
{
	CustomerModel customerModel = mapper.Map<CustomerModel>(request);

	CreateResult result = await customerFeatures.Create(customerModel);

	return result.GenerateCreateResponse(getEndpointName: _getEndpointName, routeValues: new
	{
		CustomerId = customerModel.CustomerId
	});
}

private static async Task<Results<NoContent, NotFound, BadRequest<string>, InternalServerError>> Update([FromBody] UpdateCustomerRequest request, ICustomerFeatures customerFeatures, IMapper mapper)
{
	CustomerModel customerModel = mapper.Map<CustomerModel>(request);

	UpdateResult result = await customerFeatures.Update(customerModel);

	return result.GenerateUpdateResponse();
}

private static async Task<Results<NoContent, NotFound, BadRequest<string>, InternalServerError>> Delete(Ulid customerId, ICustomerFeatures customerFeatures)
{
	DeleteResult result = await customerFeatures.Delete(customerId);

	return result.GenerateDeleteResponse();
}

public static async Task<Results<Ok<GetCustomerResponse>, NotFound, BadRequest<string>, InternalServerError>> Get(Ulid customerId, ICustomerFeatures customerFeatures)
{
	GetResult<GetCustomerResponse> result = await customerFeatures.Get(customerId);

	return result.GenerateGetResponse();
}