# Overview
Sample online shopping site and management system using CDBC architecture.
It use cdbc service provided by demo.cdbc.cloud. You need not build cdbc service yourself.

# Authentication Information
 You can use following authentication information to access demo cdbc service.

## 1. Management (Windows application)
A windows application used to do product management.
You can use it to add or edit products and confirm the modification through online shop.
### app.config
Use following setting in your app.config
```
  <appSettings>
    <add key="ApplicationId" value="demosystemclient" />
    <add key="ApplicationPsk" value="s8SReQxUnX59h6up" />
    <add key="ConnectionString" value="oracle_demostore" />
  </appSettings>
``` 

### Login form
|Property|Value|
----|---- 
| userId |demouser1|
| UserPassword |X7bgGMLh|
 

##  2. PcStore  (web application)
Sample online shopping site.  
[Online demo](https://demo.cdbc.cloud/pcstore/)
### web.config
Use following setting in your web.config

```
  <appSettings>
    <add key="ApplicationId" value="demosystemweb" />
    <add key="ApplicationPsk" value="fM4qYAaxvN4HpWQj" />
    <add key="UserId" value="demouserwebadmin" />
    <add key="UserPassword" value="Qc8jbzNE" />
    <add key="ConnectionString" value="oracle_demostore" />
  </appSettings>
```

# Diagram
<img src="https://www.cdbc.cloud/img/github/cdbcsystemsample.png" alt="cdbc sample system diagram" width="600" title="cdbc sample system diagram">


