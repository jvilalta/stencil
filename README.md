# stencil
Data driven template rendering

## Why?
Stencil is a utility I use to generate code from templates. It is designed to be simple and easy to use, while still being powerful enough to handle complex scenarios. It replaces the need for writing custom code generation scripts, and allows you to focus on defining your templates and data.

## Example
```bash
.\stencil.cli.exe render --template stencil\ingresses.scriban --output ingresses.yaml --data stencil\analytics_ingresses.txt --data-type TXT
```
