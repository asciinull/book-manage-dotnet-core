FROM hub.tencentyun.com/savory-package/savory-package-dotnet AS DOTNET_CORE_TOOL_CHAIN

COPY BookManage /tmp

WORKDIR /tmp

RUN dotnet publish -c Release


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

MAINTAINER harriszhang@live.cn

COPY --from=DOTNET_CORE_TOOL_CHAIN /tmp/bin/Release/netcoreapp2.2/publish /app

WORKDIR /app

ENTRYPOINT ["dotnet", "BookManage.dll"]
