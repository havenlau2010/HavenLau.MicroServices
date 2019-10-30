## IDS4 概念

- IdentityServer4 is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core 2.

- IdentityServer是基于OpenID Connect协议标准的身份认证和授权程序，它实现了OpenID Connect 和 OAuth 2.0 协议。 

- 安全令牌服务（Security Token Service），身份提供（Identity Provider），授权服务器（Authorization Server），IP-STS 等等。 

- 目的都是在软件应用中为客户端颁发令牌并用于安全访问的。 

  

## 功能

+ 保护资源
+ 使用本地账户或通过外部身份提供程序对用户进行验证
+ 提供会话管理或者单点登录
+ 管理和验证客户机
+ 向客户机发出标识和访问令牌
+ 验证令牌



## 白皮书

 ![img](https://img2018.cnblogs.com/blog/1468246/201903/1468246-20190306172030731-1688008591.png) 



1. 相关知识点

   + OAuth 2.0
   + OpenID
   + 客户端授权模式
   + 密码授权模式
   + 授权码授权模式
   + 简化授权模式
   + 混合模式
   + 集成 ASP.NET Core Identity and EntityFramework Core
   + 单点登录（SSO）
   + 刷新登录（Refresh Token）
   + 外部登录（微信、QQ、Github）

2. 授权模式流程图

   +  ![img](https://img2018.cnblogs.com/blog/1468246/201903/1468246-20190306175842023-1603947050.png) 
   +  ![img](https://img2018.cnblogs.com/blog/1468246/201903/1468246-20190306180817322-384823618.png) 

3. 相关文档

   + IdentityServer4  https://identityserver4.readthedocs.io/en/latest/ 

   + OAuth 2.0 https://oauth.net/2/

   + OpenID Connect https://openid.net/connect

     

## 相关术语

1. IdentityServer（身份认证服务器）
2. User（用户）
3. Client （客户端）
4. Resources （资源）
5. Identity Token（身份令牌）
6. Access Token（访问令牌）
7. Refresh Token（刷新令牌）
8. OAuth 2.0
9. OpenID Connect
10. JWT

## 实战
1. 创建Identiy Server 
	
	+ 创建ASP.NET Core Web 项目
	+ 在launchSettings.json 删除 IIS 配置
	+ 设置 Server的固定端口号 比如：5000
	
2. 安装并配置IdentityServer4

   + 添加IdentityServer4包

   + 配置认证服务中间管道

     `app.UseIdentityServer();`

   + 配置IdentityServer相关服务

3. 配置详情

   + 当前Server保护了哪些资源（API）
   + 哪些客户端（Client）可以使用这个当前Server
   + 指定可以使用当前Server的用户（User）
   + 指定作用域定义系统中的IdentityResources资源

4. 