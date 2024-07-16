private const string _routePrefix = "api/Product";
private const string _getEndpointName = $"{_routePrefix}/{nameof(Get)}";

public static void MapEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
{
	RouteGroupBuilder routeGroupBuilder = endpointRouteBuilder.MapGroup(_routePrefix);

	routeGroupBuilder.MapPost("/", Create);
	routeGroupBuilder.MapPut("/", Update);
	routeGroupBuilder.MapDelete("/", Delete);
	routeGroupBuilder.MapGet("/", Get).WithName(_getEndpointName);
}

private static async Task<Results<CreatedAtRoute, BadRequest<string>, InternalServerError>> Create([FromBody] CreateProductRequest request, IProductFeatures productFeatures, IMapper mapper)
{
	ProductModel productModel = mapper.Map<ProductModel>(request);

	CreateResult result = await productFeatures.Create(productModel);

	return result.GenerateCreateResponse(getEndpointName: _getEndpointName, routeValues: new
	{
		ProductId = productModel.ProductId
	});
}

private static async Task<Results<NoContent, NotFound, BadRequest<string>, InternalServerError>> Update([FromBody] UpdateProductRequest request, IProductFeatures productFeatures, IMapper mapper)
{
	ProductModel productModel = mapper.Map<ProductModel>(request);

	UpdateResult result = await productFeatures.Update(productModel);

	return result.GenerateUpdateResponse();
}

private static async Task<Results<NoContent, NotFound, BadRequest<string>, InternalServerError>> Delete(Ulid productId, IProductFeatures productFeatures)
{
	DeleteResult result = await productFeatures.Delete(productId);

	return result.GenerateDeleteResponse();
}

public static async Task<Results<Ok<GetProductResponse>, NotFound, BadRequest<string>, InternalServerError>> Get(Ulid productId, IProductFeatures productFeatures)
{
	GetResult<GetProductResponse> result = await productFeatures.Get(productId);

	return result.GenerateGetResponse();
}