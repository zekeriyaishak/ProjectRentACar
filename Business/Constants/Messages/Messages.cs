﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages;

public static class Messages
{
    public static string BrandAdded = "Marka eklenmiştir";
    public static string BrandDeleted = "Marka silinmiştir";
    public static string BrandUpdated = "Marka güncellenmiştir";
    public static string BrandListed = "Markalar getirilmiştir";
    public static string ColorAdded = "Renk eklenmiştir";
    public static string ColorDeleted = "Renk silinmiştir";
    public static string ColorUpdated = "Renk güncellenmiştir";
    public static string ColorListed = "Renkler getirilmiştir";
    public static string CarAdded = "Araba eklenmiştir";
    public static string CarDeleted = "Araba silinmiştir";
    public static string CarUpdated = "Araba güncellenmiştir";
    public static string CarListed = "Arabalar getirilmiştir";

    public static string UserNotFound = "Kullanıcı bulunamadı";
    public static string PasswordError = "Şifre hatalı";
    public static string SuccessfulLogin = "Sisteme giriş başarılı";
    public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
    public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
    public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

    public static string UserAdded = "Kullanıcı eklenmiştir";
    public static string UserDeleted = "Kullanıcı silinmiştir";
    public static string UserListed = "Kullanıcılar listelenmiştir";
    public static string UserUpdate = "Kullanıcı güncellenmiştir";

    public static string CarImageAdded = "Araba resmi eklendi";
    public static string CarImageDelete = "Araba resmi silindi";
    public static string CarImageGetAll = "Araba resimleri gelmiştir";
    public static string CarImageUpdate = "Araba resimi güncellenmiştir";
    public static string CarImageLimitExceded = "En fazla bir arabaya 5 resim ekleyebilirsiniz";

    public static string CustomerAdded = "Müşteri eklenmiştir";
    public static string CustomerDeleted = "Müşteri Silinmiştir";
    public static string CustomerListed = "Müşteriler listelenmiştir";
    public static string CustomerUpdate = "Müşteriler Güncellenmiştir";

    public static string RentAlAdded = "Kiralanacak araç eklendi";
    public static string RentAlDeleted = "Kiralanan araba silinmiştir";
    public static string RentAlUptaded = "Kiralanacak araç güncellendi";
    public static string RentAlListed = "Kiralanacak araçlar listelendi";
    public static string RentCarNotDescription = "Aracın açıklaması boş geçilemez";
    public static string RentACarNotAvailable = "Araç belirtilen aralıkta uygun değil.";
    public static string RentACarAvailable = "Belirtilen tarihte araç durumu müsait";
}
