using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class SessionCart: Cart
    {
        [JsonIgnore]
        public ISession Session;

        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            // get current session
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        /// <summary>
        /// Overrided addItem and set session
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="product"></param>
        public override void AddItem(int quantity, Product product)
        {
            base.AddItem(quantity, product);
            Session.SetJson("Cart", this);
        }

        /// <summary>
        /// Overrided removeItem and set session
        /// </summary>
        /// <param name="product"></param>
        public override void RemoveLineItem(Product product)
        {
            base.RemoveLineItem(product);
            Session.SetJson("Cart", this);
        }

        /// <summary>
        /// Overrided clearline and setsession
        /// </summary>
        public override void ClearLine()
        {
            base.ClearLine();
            Session.Remove("Cart");
        }
    }
}
