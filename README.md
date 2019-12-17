# ePlatform-api-dotnet-client

## Turkcell e-Şirket e-Belge uygulamaları için .Net Client


NuGet paketini, nuget.org üzerinden uygulamanıza dahil edebilirsiniz.

> dotnet add package ePlatform.Api.eBelge.Invoice --version 1.1.0

> Install-Package ePlatform.Api.eBelge.Invoice -Version 1.1.0

### Kullanım

.Net Core projesinizde, startup.cs dosyasında, ConfigureServices kısmına, Client için gerekli kısımları eklemelisiniz.

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDistributedMemoryCache(); //Token cache için gerekli
        services.AddePlatformClients(Configuration);
    }

Uygulamanızın AppSettings.json dosyasında, Client için gerekli ilgili model yer almalıdır.

    "ePlatformClientOptions": {
        "AuthServiceUrl": "https://coretest.isim360.com",
        "InvoiceServiceUrl": "https://efaturaservicetest.isim360.com",
        "Auth": {
        //Test için aşağıdaki kullanıcı bilgilerini kullanabilir yada özel kullanıcı talep edebilirsiniz.
        "Username": "serviceuser01@isim360.com",
        "Password": "ePlatform123+",
        "ClientId": "serviceApi"
        }
    }

sample dizini içerisinde yer alan projeler vasıtasıyla örnek kullanımları görebilir, .Net Core ve .Net 4.6 için hazırlanan örnekleri inceleyebilirsiniz.

## Teknik dökümantasyon
[https://developer.turkcellesirket.com/](https://developer.turkcellesirket.com/)

## Soru ve yorumlarınız için
    entegrasyon@eplatform.com.tr