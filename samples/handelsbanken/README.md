# Handelsbanken Sandbox Sample

## Prerequisites
- [Node.js](https://nodejs.org/en/)
- npm (comes with node.js)
- Developer account at [Handelsbanken](https://developer.handelsbanken.com/user/register)
- Handelsbanken application (to get a client ID)
- Activated subscriptions to the API's you want to try out at Handelsbanken

## Project setup
Install dependencies by running the following command.
```
npm install
```
Make a copy of the `.env.example` file and save as `.env` in the root directory. 
```
cp .env.example .env
```
Make sure the fill the `.env` file with actual values for the demo endpoints to work!

### Start the server
```
npm run start
```

### Try out the endpoints
Open up your web browser at `localhost:9000` to try out the endpoints.

## Do what you do!
Start off by exploring the API documentation for the services.
- [Handelsbanken](https://developer.handelsbanken.com/psd2/accounts)
    - Note: you **must** subscribe to the different API's to use them or even reach their documentation. Do this by logging in and then visiting, for instance, https://developer.handelsbanken.com/psd2/accounts/v2 and clicking subscribe.