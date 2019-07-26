using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPos.Domain;

namespace WirelessPOS
{
    public class EntityLoader
    {
        public async static Task LoadComponents(Purchase entity, Adapter adapter)
        {
            if (entity != null)
            {
                await adapter.LoadRelatedData(entity);

                foreach (var purchaseItem in entity.PurchaseItems)
                {
                    await adapter.LoadRelatedData(purchaseItem);
                    await adapter.LoadRelatedData(purchaseItem.Item);
                }
            }
        }

        public async static Task LoadComponents(Sale entity, Adapter Adapter)
        {
            if (entity != null)
            {
                await Adapter.LoadRelatedData(entity);

                foreach (var saleItem in entity.SaleItems)
                {
                    await Adapter.LoadRelatedData(saleItem);
                    await Adapter.LoadRelatedData(saleItem.StockItem);
                    await Adapter.LoadRelatedData(saleItem.StockItem.PurchaseItem);
                    await Adapter.LoadRelatedData(saleItem.StockItem.PurchaseItem.Item);
                }
            }
        }

        public async static Task LoadComponents(Repair entity, Adapter Adapter)
        {
            if (entity != null)
            {
                await Adapter.LoadRelatedData(entity);

                foreach (var saleItem in entity.SaleItems)
                {
                    await Adapter.LoadRelatedData(saleItem);
                    await Adapter.LoadRelatedData(saleItem.StockItem);
                    await Adapter.LoadRelatedData(saleItem.StockItem.PurchaseItem);
                    await Adapter.LoadRelatedData(saleItem.StockItem.PurchaseItem.Item);
                }

                foreach (var policy in entity.Policies)
                {
                    await Adapter.LoadRelatedData(policy);
                }
            }
        }

        public async static Task LoadComponents(Layaway entity, Adapter Adapter)
        {
            if (entity != null)
            {
                await Adapter.LoadRelatedData(entity);

                foreach (var saleItem in entity.SaleItems)
                {
                    await Adapter.LoadRelatedData(saleItem);
                    await Adapter.LoadRelatedData(saleItem.StockItem);
                    await Adapter.LoadRelatedData(saleItem.StockItem.PurchaseItem);
                    await Adapter.LoadRelatedData(saleItem.StockItem.PurchaseItem.Item);
                }

                foreach (var policy in entity.Policies)
                {
                    await Adapter.LoadRelatedData(policy);
                }

            }
        }

        public async static Task LoadComponents(NewActivation entity, Adapter Adapter)
        {
            if (entity != null)
            {
                await Adapter.LoadRelatedData(entity);

                foreach (var policy in entity.Policies)
                {
                    await Adapter.LoadRelatedData(policy);
                }

            }
        }

        public async static Task LoadComponents(Portin entity, Adapter Adapter)
        {
            if (entity != null)
            {
                await Adapter.LoadRelatedData(entity);

                foreach (var policy in entity.Policies)
                {
                    await Adapter.LoadRelatedData(policy);
                }

            }
        }

        public async static Task LoadComponents(Payment entity, Adapter Adapter)
        {
            if (entity != null)
            {
                await Adapter.LoadRelatedData(entity);

                foreach (var policy in entity.Policies)
                {
                    await Adapter.LoadRelatedData(policy);
                }

            }
        }

        public async static Task LoadComponents(Unlock entity, Adapter Adapter)
        {
            if (entity != null)
            {
                await Adapter.LoadRelatedData(entity);

                foreach (var policy in entity.Policies)
                {
                    await Adapter.LoadRelatedData(policy);
                }

            }
        }

        public async static Task LoadComponents(CallingCard entity, Adapter Adapter)
        {
            if (entity != null)
            {
                await Adapter.LoadRelatedData(entity);

                foreach (var policy in entity.Policies)
                {
                    await Adapter.LoadRelatedData(policy);
                }

            }
        }

    }
}
