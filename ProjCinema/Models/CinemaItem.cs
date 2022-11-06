using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjCinema.Models
{
    public class AdminInfo
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string DepartmentName { get; set; }
    }
    public class CinemaInfo
    {
        public string CinemaID { get; set; }
        public string CinemaName { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string CinemaAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class RoomInfo
    {
        public string RoomID { get; set; }
        public string RoomName { get; set; }
        public string CinemaID { get; set; }
        public string CinemaName { get; set; }
        public string ScreenType { get; set; }
    }
    public class ShowTime
    {
        public string showtime { get; set; }

        public string screentype { get; set; }
        public string roomid { get; set; }
        public string movietimeid { get; set; }
        public virtual int seat_available { get; set; }
    }
    public class CinemaItem1
    {
        [StringLength(100)]
        public string CinemaName { get; set; }
        [StringLength(100)]
        public string CinemaAddress { get; set; }
        public virtual List<ShowTime> type1 { get; set; }
        public virtual List<ShowTime> type2 { get; set; }
        public virtual List<ShowTime> type3 { get; set; }
    }
    public class MovieItem
    {
        [StringLength(50)]
        public string MovieID { get; set; }
        [StringLength(50)]
        public string MovieName { get; set; }
        [StringLength(50)]
        public string Director { get; set; }
        [StringLength(100)]
        public string Actor { get; set; }
        [StringLength(30)]
        public string Category { get; set; }
        public double? IMDb { get; set; }
        public byte? MovieLength { get; set; }
        public byte? Rate { get; set; }
        public byte? MovieStatus { get; set; }
        [StringLength(100)]
        public string PosterLink { get; set; }
        public virtual List<ShowTime> type1 { get; set; }
        public virtual List<ShowTime> type2 { get; set; }
        public virtual List<ShowTime> type3 { get; set; }
    }
    public class SelectTicket
    {
        [StringLength(50)]
        public string MovieName { get; set; }
        [StringLength(50)]
        public string CinemaName { get; set; }
        [StringLength(100)]
        public string CinemaAddress { get; set; }
        [StringLength(30)]
        public string ShowTime { get; set; }
        [StringLength(30)]
        public string ScreenType { get; set; }
    }
    public class Bill_Info
    {
        public string BillID { get; set; }

        [StringLength(10)]
        public string UserID { get; set; }

        [StringLength(20)]
        public string TicketSession { get; set; }

        [StringLength(20)]
        public string ServiceSession { get; set; }

        [StringLength(10)]
        public string CodeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PayDay { get; set; }

        public virtual DISCOUNT_CODE DISCOUNT_CODE { get; set; }

        [StringLength(30)]
        public virtual List<SEAT> Seat { get; set; }
        public virtual Bill_data data { get; set; }
        public virtual List<TICKET_2> TicketType { get; set; }
        public virtual List<SERVICE_TO_CASH> Service { get; set; }

        public virtual USER_ACCOUNT USER_ACCOUNT { get; set; }
    }
    public class Bill_data
    {
        public virtual string MovieName { get; set; }
        public virtual string ShowTime { get; set; }
        public virtual string RoomName { get; set; }
        public virtual string CinemaName { get; set; }
        public virtual string CinemaAddress { get; set; }
        public virtual string LocationName { get; set; }

    }
    public class TICKET_2
    {
        [StringLength(20)]
        public string TicketID { get; set; }

        [StringLength(20)]
        public string SeatID { get; set; }
        public string SeatName { get; set; }

        [StringLength(20)]
        public string TicketSession { get; set; }


    }
    public class FeedbackList
    {
        [StringLength(10)]
        public string FeedbackID { get; set; }

        [StringLength(100)]
        public string FeedbackContent { get; set; }
        [StringLength(100)]
        public string email { get; set; }
    }
}
