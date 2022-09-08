# Running SDK Tests

Build and run the container using `docker-compose`

```
$ docker-compose up --build && docker-compose rm -f
```

## Test Configuration

# Method 1; secrets.json
Create a file named `secrets.json` in the `Lusid.Drive.Sdk.Tests` folder with the structure below and populated with the appropriate values.

``` json
{
  "api" : {
    "tokenUrl": "",
    "username": "",
    "password": "",
    "clientId": "",
    "clientSecret": "",
    "driveUrl": ""
  }
}
```

| Key | Description |
| --- | --- |
| `tokenUrl` | Okta endpoint to generate the authentication token.  This will be of the form https://lusid.okta.com/oauth2/\<key\>/v1/token |
| `username` | Okta username |
| `password` | Okta password |
| `clientId` | Okta client identifier |
| `clientSecret` | Okta client secret |
| `driveUrl` | API url |

## Method 2; environment variables
You can supply one of two sets of environent variables to docker compose when running the tests.
### set 1
This is analogous to creating the secrets file.  See [this article](https://support.lusid.com/knowledgebase/article/KA-01663/) for information on getting these variables.
- FBN_TOKEN_URL
- FBN_USERNAME
- FBN_PASSWORD
- FBN_CLIENT_ID
- FBN_CLIENT_SECRET
- FBN_APP_NAME
- FBN_BASE_API_URL

FBN_BASE_API_URL is the url to the root domain of your LUSID account.  i.e. https://my-domain.lusid.com

### set 2
This method requires that you supply an access token directly.  You must source this yourself; See Step 3 [of this article](https://support.lusid.com/knowledgebase/article/KA-01667/)
- FBN_BASE_API_URL
- FBN_ACCESS_TOKEN

FBN_BASE_API_URL is the url to the root domain of your LUSID account.  i.e. https://company-x.lusid.com
