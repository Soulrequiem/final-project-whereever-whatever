/***************************************************************************/
/*  File Name       : ReceiveOrderForm.cs
/*  Module Name     : UI
/*  Owner           : JinChengCheng
/*  class Name      : ReceiveOrderForm
/*  Details         : UI representation of ReceiveOrderFormUI 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;
using SystemStoreInventorySystemUtil;


namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class ReceiveOrderForm : System.Web.UI.Page
    {
        private static readonly string sessionKey = "ReceiveOrderForm";
        //ReceiveOrderControl ROobj;
        //PurchaseOrderControl purchaseOrderControl;
        ReceiveOrderControl receiveOrderControl;
        int selectedItem;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                    receiveOrderControl = new ReceiveOrderControl();
                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, receiveOrderControl);
                    FillPOList();
             }
               
            else
            {
                receiveOrderControl = (ReceiveOrderControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }

            
        }

        /// <summary>
        /// Selected item from item drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DrdPONo_SelectionChanged(object sender,
        Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            FillStationeryOrder();
        }

        private void FillStationeryOrder()
        {
            try
            {
                selectedItem = SystemStoreInventorySystemUtil.Converter.objToInt(DrdPONo.SelectedValue);
                DgvStationeryOrder.DataSource = receiveOrderControl.GetPurchaseOrderDetail(selectedItem);
                DgvStationeryOrder.DataBind();
                string[] labels = receiveOrderControl.GetLabelData(selectedItem);
                lblSupplierName.Text = labels[0];
                lblDeliveryDate.Text = labels[1];
                //ROobj = new ReceiveOrderControl();
                //********Plz check this
                //DataTable dt = ROobj.SelectPurchaseOrderDetails(Convert.ToInt32(selectedItem));
                //FillStationeryOrder(dt);

                //********get supplier name by PONumber
                //Label1.Text = ReceiveOrderControl.GetSupplierName(selectedItem);
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        private void FillPOList()
        {
            try
            {
                //purchaseOrderControl = new PurchaseOrderControl();
                //***********Get all purchase order list
                //DataTable dt = ROobj.PurchaseOrderList; //GetPO();
                DrdPONo.TextField = "poNumber";
                DrdPONo.ValueField = "poNumber";
                DrdPONo.DataSource = receiveOrderControl.PurchaseOrderNo;
                DrdPONo.DataBind();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        protected void btnReceived_Click(object sender, EventArgs e)
        {
            //FillStationeryOrder();
            //*********update purchase order
            //*********insert stock card details in stock card
            //receiveOrderControl.SelectReceived((DataTable)DgvStationeryOrder.DataSource); 
            DataTable dt = new DataTable();
            dt.Columns.AddRange(receiveOrderControl.DetailColumn);

            DataRow dr;
            for (int i = 0; i < DgvStationeryOrder.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["itemNo"] = DgvStationeryOrder.Rows[i].Items[0].Value.ToString();
                dr["itemDescription"] = DgvStationeryOrder.Rows[i].Items[1].Value.ToString();
                dr["quantity"] = ((Infragistics.Web.UI.EditorControls.WebTextEditor)DgvStationeryOrder.Rows[i].Items.FindItemByKey("quantity").FindControl("quantity")).Text;
                dr["Remarks"] = ((Infragistics.Web.UI.EditorControls.WebTextEditor)DgvStationeryOrder.Rows[i].Items.FindItemByKey("Remarks").FindControl("Remarks")).Text;
                dt.Rows.Add(dr);
            }



            string deliveryNo = txtDeliveryOrderNo.Text;
            string poNo = DrdPONo.SelectedValue;

            if (receiveOrderControl.ClickReceived(dt, deliveryNo, poNo) == Constants.ACTION_STATUS.SUCCESS)
            {
                Response.Write("SUCESS.....");

            }
            else
            {
                Response.Write("FAIL.......");
            }
        }

        
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
