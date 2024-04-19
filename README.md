# Неофициальная обертка для сервиса фискализации Атол-Онлайн

[![Build](https://github.com/ili/atol-online/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ili/atol-online/actions) [![NuGet Version and Downloads count](https://buildstats.info/nuget/AtolOnline.Unofficial?includePreReleases=true)](https://www.nuget.org/packages/AtolOnline.Unofficial)

Документация Атол

* https://atol.online/library/?tab=devs
* [Протокол V4: ФФД 1.05](https://atol.online/upload/iblock/dff/4yjidqijkha10vmw9ee1jjqzgr05q8jy/API_atol_online_v4.pdf)
* [Протокол V5: ФФД 1.2](https://atol.online/upload/iblock/114/lbmvx23d1xvz0jwh88d11fi0hhc3q7yk/API%20%D1%81%D0%B5%D1%80%D0%B2%D0%B8%D1%81%D0%B0%20%D0%90%D0%A2%D0%9E%D0%9B%20%D0%9E%D0%BD%D0%BB%D0%B0%D0%B9%D0%BD_v5.pdf)

## Особенности

* Поддержка протоколов V4 и V5
* Модели сделаны исходя из протокола V5, автоматическое преодразование признака предмета расчета из V5 (число) в V4 (строка)

## Пример

```c#
using using AtolOnline.Unofficial;

var client = new AtolClient(_httpClient);
var token = await client.GetTokenAsync(myLogin, myPassword);

var ans = await client.SellAsync(token.Token, myGroupCode, myReceipt);

try
{
    var status = await client.ReportAsync(token.Token, myGroupCode, ans.Uuid);
}
catch(AtolClientException ex)
{
    if (ex.Response is FailReportResponse frr)
    {
        // чек ещё не обработан
    }
}

```
