using NewYearGifts;
using NewYearGifts.Services;

var app = new App(new GiftService(10));

app.Start();