# ePlatform-api-dotnet-client

## Turkcell e-Şirket e-Belge uygulamaları için .Net Client


NuGet paketi olan, ePlatform.eBelge.Api.Client.{version}.nupkg paketini projenize eklemelisiniz.

Paket sürümü netstandard2.0 ve üstünü desteklemektedir. .Net 4.6 desteği ilerleyen zamanlarda kazandırılacaktır.

### Kullanım

.NetCore projesinizde, startup.cs dosyasında, ConfigureServices kısmına, Client için gerekli kısımları eklemelisiniz.

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

Sample projesinden yer alan Controller'lar içerisinde görebileceğiniz şekilde, ilgili servisleri inject edip kullanmanız gerekmektedir.

## Teknik dökümantasyon
[https://developer.turkcellesirket.com/](https://developer.turkcellesirket.com/)

## Soru ve yorumlarınız için
    entegrasyon@eplatform.com.tr