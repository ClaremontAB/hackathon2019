# Discover:Hackathon
Information on Discover:Hackathon at Claremont

## Communication
We encourage you to use our Slack channel: https://claremont-hackathon.slack.com. You should have gotten an invite in your mailbox previously, otherwise contact oskar.lind@claremont.se.

## API:s

### Handelsbanken
Erik Forsberg (Claremont) created an awesome guide for Handelsbanken which is available [here](samples/handelsbanken).
https://developer.handelsbanken.com/getting-started
1. Sign up for a developer account at https://developer.handelsbanken.com/user/register
2. Register you app and get a clientid at https://developer.handelsbanken.com/application
3. Subscribe to the apies you want to have access to.
    * Account Information Service Providers (AISP) 
       * https://developer.handelsbanken.com/psd2/accounts/v2
       * https://developer.handelsbanken.com/psd2/consents/v1
    * Payment Initiation Service Providers (PISP)
       * https://developer.handelsbanken.com/psd2/payments/v1
    * Card Based Payment Instrument Issuer (CBPII)
       * https://developer.handelsbanken.com/psd2/funds-confirmations
4. Use example auth token from https://developer.handelsbanken.com/files/shb-psd2-accounts-testdata.pdf

Example postman collection for Handelsbanken (just add you clientid) [Postman collection](shb-psd2-postman_collection.json)

### SEB
https://developer.sebgroup.com
1. Sign up for a developer account on https://developer.sebgroup.com/user/register
2. Read "Getting started" at https://developer.sebgroup.com/getting-started

SEB uses oauth2 flow for authentication. Create a new app here: https://developer.sebgroup.com/application/new

### Swedavia
https://apideveloper.swedavia.se
1. Sign up for an account at https://apideveloper.swedavia.se/signup
2. Go to "https://apideveloper.swedavia.se/getting-started" for a useful overview on how to use the API:s
3. Happy hacking!

### Trafiklab
https://www.trafiklab.se
and https://www.trafiklab.se/hur-gor-jag
1. Sign up for an accout at https://www.trafiklab.se/user/register
2. Create a project
3. Get an API key to use in your API calls
4. Happy hacking!

### SMHI
No account needed. Access to weather forecasts for a specific geographical location.
http://opendata.smhi.se/apidocs/metfcst/index.html
http://opendata.smhi.se/apidocs/metfcst/demo_point.html

### Öppna data
https://oppnadata.se/
Public sector data. 

### Other sources
- apikatalogen.se
