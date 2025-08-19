namespace OnlineShopForBags.Services
{
    public class ShoppingCartService
    {
        private readonly HttpContext httpContext;
        private const string CartCookieName = "CartId";

        public ShoppingCartService(HttpContext httpContext)
        {
            this.httpContext = httpContext;
        }

        public string GetOrCreateCartId()
        {
            var cartId = httpContext.Request.Cookies[CartCookieName];

            if (string.IsNullOrEmpty(cartId))
            {
                cartId = Guid.NewGuid().ToString();
                httpContext.Response.Cookies.Append(
                    CartCookieName,
                    cartId,
                    new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddDays(2), 
                        HttpOnly = true,
                        Secure = true
                    });
            }

            return cartId;
        }
    }
}
