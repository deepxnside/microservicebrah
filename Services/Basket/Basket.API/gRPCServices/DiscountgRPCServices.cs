

using Discount.gRPC.Protos;

namespace Basket.API.gRPCServices;

public class DiscountgRPCServices
{
    private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

    public DiscountgRPCServices(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
    {
        _discountProtoServiceClient = discountProtoServiceClient;
    }


    public async Task<CouponModel> GetDiscount(string productName)
    {
        var discountRequest = new GetDiscountRequest { ProductName = productName };
        return await _discountProtoServiceClient.GetDiscountAsync(discountRequest);
    }
}