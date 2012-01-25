
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.broker
{
    public class StockCardBroker : IStockCardBroker
    {
        private InventoryEntities inventory = new InventoryEntities();
        private StockCard stc = null;
        private StockCardDetail stcDetail = null;
        private List<StockCard> stcList = null;
        private List<StockCardDetail> stcDetailList = null;

        public StockCard GetStockCard(StockCard stockCard)
        {
            stc = inventory.StockCards.Where(stcObj => stcObj.Id == stockCard.Id).First();
            stc.ItemReference = stockCard.ItemReference;
            if (!stc.Equals(null))
            {
                var stockCardDetailResult = from sc in inventory.StockCardDetails
                                            where sc.StockCard.Id == stc.Id
                                            select sc;
                foreach (StockCardDetail sc in stockCardDetailResult)
                {
                    stc.StockCardDetails.Add(sc);

                }
            }
            return stc;
        }

        public List<StockCard> GetAllStockCard()
        {
            stcList = inventory.StockCards.ToList<StockCard>();
            if (!stcList.Equals(null))
                return stcList;
            return null;
        }
        public Constants.DB_STATUS Insert(StockCard stockCard)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToStockCards(stockCard);
                foreach (StockCardDetail stockCardDetail in stockCard.StockCardDetails)
                {
                    this.Insert(stockCardDetail);
                }
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        public Constants.DB_STATUS Update(StockCard stockCard)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                foreach (StockCardDetail stockCardDetail in stockCard.StockCardDetails)
                {
                    this.Update(stockCardDetail);
                }
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }
        public Constants.DB_STATUS Delete(StockCard stockCard)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;
            try
            {
                stc = inventory.StockCards.Where(stcObj => stcObj.Id == stockCard.Id).First();
                stc.Status = 2;
                foreach (StockCardDetail stockCardDetail in stockCard.StockCardDetails)
                {
                    this.Delete(stockCardDetail);
                }

                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;

        }
        public StockCardDetail GetStockCardDetail(StockCardDetail stockCardDetail)
        {
            stcDetail = inventory.StockCardDetails.Where(stcDetailObj => stcDetailObj.Id == stockCardDetail.Id).First();
            if (!stcDetail.Equals(null))
                return stcDetail;
            return null;
        }

        public List<StockCardDetail> GetAllStockCardDetail()
        {
            stcDetailList = inventory.StockCardDetails.ToList<StockCardDetail>();
            if (!stcDetailList.Equals(null))
                return stcDetailList;
            return null;
        }
        public Constants.DB_STATUS Insert(StockCardDetail stockCardDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;


            try
            {
                inventory.AddToStockCardDetails(stockCardDetail);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        public Constants.DB_STATUS Update(StockCardDetail stockCardDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        public Constants.DB_STATUS Delete(StockCardDetail stockCardDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

    }
}