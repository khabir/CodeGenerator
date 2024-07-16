private const string _routePrefix = "api/Order";
private const string _getEndpointName = $"{_routePrefix}/{nameof(Get)}";

public static void MapEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
{
	RouteGroupBuilder routeGroupBuilder = endpointRouteBuilder.MapGroup(_routePrefix);

	routeGroupBuilder.MapPost("/", Create);
	routeGroupBuilder.MapPut("/", Update);
	routeGroupBuilder.MapDelete("/", Delete);
	routeGroupBuilder.MapGet("/", Get).WithName(_getEndpointName);
}

private static async Task<Results<CreatedAtRoute, BadRequest<string>, InternalServerError>> Create([FromBody] CreateOrderRequest request, IOrderFeatures orderFeatures, IMapper mapper)
{
	OrderModel orderModel = mapper.Map<OrderModel>(request);

	CreateResult result = await orderFeatures.Create(orderModel);

	return result.GenerateCreateResponse(getEndpointName: _getEndpointName, routeValues: new
	{
		OrderId = orderModel.OrderId
	});
}

private static async Task<Results<NoContent, NotFound, BadRequest<string>, InternalServerError>> Update([FromBody] UpdateOrderRequest request, IOrderFeatures orderFeatures, IMapper mapper)
{
	OrderModel orderModel = mapper.Map<OrderModel>(request);

	UpdateResult result = await orderFeatures.Update(orderModel);

	return result.GenerateUpdateResponse();
}

private static async Task<Results<NoContent, NotFound, BadRequest<string>, InternalServerError>> Delete(Ulid orderId, IOrderFeatures orderFeatures)
{
	DeleteResult result = await orderFeatures.Delete(orderId);

	return result.GenerateDeleteResponse();
}

public static async Task<Results<Ok<GetOrderResponse>, NotFound, BadRequest<string>, InternalServerError>> Get(Ulid orderId, IOrderFeatures orderFeatures)
{
	GetResult<GetOrderResponse> result = await orderFeatures.Get(orderId);

	return result.GenerateGetResponse();
}