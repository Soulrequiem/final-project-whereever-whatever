﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemStoreInventorySystemUtil
{
    public class Constants
    {
        public static readonly string loginPage = "LogIn.aspx";

        public enum VISIBILITY_STATUS
        {
            UNKNOWN = 0,
            SHOW,
            HIDDEN
        }

        public enum REQUISITION_STATUS
        {
            UNKNOWN = 0,
            PENDING,
            APPROVED,
            REJECTED,
            SUBMITTED
        }

        public enum COLLECTION_STATUS
        {
            UNKNOWN = 0,
            NEED_TO_COLLECT,
            COLLECTED
        }

        public enum ITEM_CATEGORY
        {
            UNKNOWN = 0,
            CLIP,
            DISK,
            ENVELOPE,
            ERASER,
            EXERCISE,
            FILE,
            PEN,
            PUNCHER,
            PAD,
            PAPER,
            RULER,
            SCISSORS,
            TAPE,
            SHARPENER,
            SHORTHAND,
            STAPLER,
            TACKS,
            TPARENCY,
            TRAY
        }

        public enum UNIT_OF_MEASURE
        {
            UNKNOWN = 0,
            DOZEN,
            BOX,
            EACH,
            SET,
            PACKET
        }

        public enum DB_STATUS
        {
            UNKNOWN = 0,
            SUCCESSFULL,
            FAILED,
        }

        public enum ACTION_STATUS
        {
            UNKNOWN = 0,
            SUCCESS,
            FAIL
        }
    }
}