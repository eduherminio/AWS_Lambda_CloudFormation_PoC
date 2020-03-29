# AWS Lambda CloudFormation PoC

## Requirements

An existing s3 bucket (named `test-lambda-artifact` in this example)

## Instructions

Install or update Amazon.Lambda.Tools

```bash
    dotnet tool install -g Amazon.Lambda.Tools
    dotnet tool update -g Amazon.Lambda.Tools
```

Deploy the serverless application

```bash
    dotnet lambda deploy-serverless --template-file serverless.template --s3-bucket test-lambda-artifact --stack-name testLambdaStack
```

Test the lambda function

```bash
    dotnet lambda invoke-function -p "Hey!"
```

Cleanup

```bash
    dotnet lambda delete-serverless testLambdaStack
```
