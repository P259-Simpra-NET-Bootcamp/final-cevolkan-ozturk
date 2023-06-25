using AutoMapper;
using ECommerce.Base;
using ECommerce.Data;
using ECommerce.Data.Uow;
using ECommerce.Domain;
using ECommerce.Schema;
namespace ECommerce.Operation;

public class OrderService : BaseService<Order, OrderRequest, OrderResponse>, IOrderService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public OrderService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


    public override ApiResponse Insert(OrderRequest request)
    {
        var existUser = unitOfWork.Repository<User>().
            Where(x => x.Id.Equals(request.UserId)).ToList()[0];

        decimal spentAmountByCard = decimal.Zero;
        decimal earnedPointAmount = decimal.Zero;
       
        if (existUser == null)
        {
            return new ApiResponse("Username already in use.");
        }

        spentAmountByCard = request.BasketAmount - (request.CouponAmount + existUser.PointBalance);

        try
        {

            var orderEntity = mapper.Map<OrderRequest, Order>(request);
            orderEntity.CreatedAt = DateTime.UtcNow;
            orderEntity.CreatedBy = existUser.UserName;
            unitOfWork.Repository<Order>().Insert(orderEntity);

            unitOfWork.Complete();

            var orderDetailEntities = mapper.Map<List<OrderDetailRequest>, List<OrderDetail>>(request.orderDetailRequests);

            foreach(OrderDetail orderDetail in orderDetailEntities)
            {
                Product product = unitOfWork.Repository<Product>().Where(x => x.Id == orderDetail.ProductId).First();

                var tempEarnedPointAmount = product.Price * product.PercentageOfPoints;
                tempEarnedPointAmount = tempEarnedPointAmount > product.MaxPointAmount ? product.MaxPointAmount : tempEarnedPointAmount;
                earnedPointAmount = earnedPointAmount + tempEarnedPointAmount;

                orderDetail.OrderId = orderEntity.Id;
                orderDetail.CreatedAt = DateTime.UtcNow;
                orderDetail.CreatedBy = existUser.UserName;
                unitOfWork.Repository<OrderDetail>().Insert(orderDetail);
            }

            //User point change 
            existUser.PointBalance = existUser.PointBalance - request.PointAmount + earnedPointAmount;


            payByCard(request, spentAmountByCard);

            unitOfWork.Repository<User>().Update(existUser);
            unitOfWork.Complete();

            return new ApiResponse();
        }
        catch (Exception ex)
        {
            return new ApiResponse(ex.Message);
        }
    }

    private Boolean payByCard(object cardInfo, decimal amount)
    {
        // Ödeme yap
        return true;
    }


}
