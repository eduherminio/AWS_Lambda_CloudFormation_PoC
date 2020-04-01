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
    dotnet lambda deploy-serverless testLambdaStack -t serverless.template -sb test-lambda-artifact
```

Test the lambda function

```bash
    dotnet lambda invoke-function -p "Hey!"
```

Cleanup

```bash
    dotnet lambda delete-serverless testLambdaStack
```
