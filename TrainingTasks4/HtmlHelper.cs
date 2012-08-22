using System;
using System.Linq.Expressions;

namespace TrainingTasks4
{
    public class HtmlHelper<T>
    {
        private readonly T _model;

        public HtmlHelper(T model)
        {
            _model = model;
        }

        public Html InputFor<TProp>(Expression<Func<T, TProp>> selector)
        {
            var name = GetMemberInfo(selector).Member.Name;
            var value = selector.Compile()(_model);
            var html = new Html("input").Attr("type", "text").Attr("name", name).Attr("value", value).SelfClosing();
            return html;
        }

        private static MemberExpression GetMemberInfo(Expression method)
        {
            LambdaExpression lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }
    }
}