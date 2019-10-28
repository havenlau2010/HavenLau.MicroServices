##实体状态
`数据库上下文跟踪内存中的实体是否与数据库中相应的行同步，并且此信息确定调用 SaveChanges 方法时会发生的情况。 例如，将新实体传递到 Add 方法时，该实体的状态会设置为 Added。 然后调用 SaveChanges 方法时，数据库上下文发出 SQL INSERT 命令。
实体可能处于以下状态之一：
Added。 数据库中尚不存在实体。 SaveChanges 方法发出 INSERT 语句。
Unchanged。 不需要通过 SaveChanges 方法对此实体执行操作。 从数据库读取实体时，实体将从此状态开始。
Modified。 已修改实体的部分或全部属性值。 SaveChanges 方法发出 UPDATE 语句。
Deleted。 已标记该实体进行删除。 SaveChanges 方法发出 DELETE 语句。
Detached。 数据库上下文未跟踪该实体。`