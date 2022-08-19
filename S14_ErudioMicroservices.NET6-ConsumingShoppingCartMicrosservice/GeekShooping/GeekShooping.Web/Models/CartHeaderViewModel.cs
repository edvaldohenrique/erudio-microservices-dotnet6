namespace GeekShooping.Web.Models
{
    public class CartHeaderViewModel
    {
        public long Id { get; set; }
        public string UserID { get; set; }
        public string? CouponCode { get; set; }
        public double PurchaseAmount { get; set; }
    }
}
