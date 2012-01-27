/***************************************************************************/
/*  File Name       : StockCardBroker.cs
/*  Module Name     : Models
/*  Owner           : Priya
/*  class Name      : StockCard
/*  Details         : Model Representation Stockcard and Stockcard detail table
/***************************************************************************/
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
        private InventoryEntities inventory;
        private StockCard stc = null;
        private StockCardDetail stcDetail = null;
        private List<StockCard> stcList = null;
        private List<StockCardDetail> stcDetailList = null;
        public StockCardBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        /// Get the last Record of the StockCard table
        /// </summary>
        /// <returns></returns>
        public int GetStockCardId()
        {
            // return GetAllStockCard().Last().Id + 1;

            var maxStockcardId = inventory.StockCards.Max(xObj => xObj.Id) + 1;
            return maxStockcardId;

        }

        /// <summary>
        /// Retrieve the StockCard and StockCardDetail information according to the StockCard Parameter 
        /// </summary>
        /// <param name="stockCard"></param>
        /// <returns></returns>
        public StockCard GetStockCard(StockCard stockCard)
        {
            stc = inventory.StockCards.Where(stcObj => stcObj.Id == stockCard.Id).First();
           // stc.ItemReference = stockCard.ItemReference;
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
        /// <summary>
        /// Retrieve All of the StockCard information from StockCard Table
        /// </summary>
        /// <returns></returns>
        public List<StockCard> GetAllStockCard()
        {
            stcList = inventory.StockCards.ToList<StockCard>();
            if (!stcList.Equals(null))
                return stcList;
            return null;
        }
        /// <summary>
        /// Insert StockCard and StockDetail data to the StockCard and StockDetail Table according to the StockCard Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="stockCard"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update StockCard and StockDetail data to StockCard and StockDetail Table according to the StockCard Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="stockCard"></param>
        /// <returns></returns>
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
        /// <summary>
        ///  Logically delete the StockCard by setting the status to 2 in the StockCard table
        /// </summary>
        /// <param name="stockCard"></param>
        /// <returns></returns>
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
        /// <summary>
        ///  Retrieve the StockCardDetail information according to the stockCardDetail Parameter 
        /// </summary>
        /// <param name="stockCardDetail"></param>
        /// <returns></returns>
        public StockCardDetail GetStockCardDetail(StockCardDetail stockCardDetail)
        {
            stcDetail = inventory.StockCardDetails.Where(stcDetailObj => stcDetailObj.Id == stockCardDetail.Id).First();
            if (!stcDetail.Equals(null))
                return stcDetail;
            return null;
        }
        /// <summary>
        ///  Retrieve StockDetail data to the StockDetail Table according to the StockCardDetail Parameter
        /// </summary>
        /// <returns></returns>
        public List<StockCardDetail> GetAllStockCardDetail()
        {
            stcDetailList = inventory.StockCardDetails.ToList<StockCardDetail>();
            if (!stcDetailList.Equals(null))
                return stcDetailList;
            return null;
        }
        /// <summary>
        /// Insert StockDetail data to StockDetail Table according to the StockDetail Parameter Return Constants.DB_STATUS
        /// </summary>
        /// <param name="stockCardDetail"></param>
        /// <returns></returns>
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
        /// <summary>
        ///  Update StockDetail data to StockDetail Table according to the StockDetail Parameter
        ///   Return Constants.DB_STATUS
        /// </summary>
        /// <param name="stockCardDetail"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Don't need to set the status.There is no status in StockCardDetail Table
        /// </summary>
        /// <param name="stockCardDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(StockCardDetail stockCardDetail)
        {
            throw new NotImplementedException();
        }

    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/