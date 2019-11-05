## Health Check



### 为什么要Health Check

> 1. 运行状况探测可以由容器业务流程协调程和负载均衡器用于<u>检查应用的状态</u>。例如： 容器业务流程协调程序可以通过停止滚动部署或重新启动容器来响应失败的运行状况检查。   负载均衡器可以通过将流量从失败的实例路由到正常实例，来应对不正常的应用。 
> 2. 可以监视内存、磁盘和其他服务器资源的使用情况来了解是否处于正常状态
> 3. 运行状况检查可以测试应用的依赖项（如数据库和外部服务终结点）以确认是否可用和正常工作

### 如何使用

1. 安装和运行
   `Install-Package Microsoft.Extensions.Diagnostics.HealthChecks`

2. 注入

   ` services.AddHealthChecks(); `

   `app.UseHealthChecks("/health");`

### 自定义健康检查
> 使用匿名方法快速实现
```
servicss.AddHealthChecks().AddCheck("checkdb",()=>
{ 
	return HealthCheckResult.Healthy(); 
});
```

> 使用自定义类进行封装
```
public class DatabaseHealthCheck : IHealthCheck
{
	public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
    	using var connection = new SqlConnection("Data Source=.;Persist Security Info=True;User ID=sa;Password=Lwz3.131492653");
        try
        {
        	connection.Open();
		}
        catch (Exception ex)
        {
        	return Task.FromResult(HealthCheckResult.Unhealthy());
        }
        return Task.FromResult(HealthCheckResult.Healthy());
	}
}
```


