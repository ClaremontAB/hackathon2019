require('dotenv').config()
const express = require('express')
const bank = require('./handelsbanken')
const app = express()
const port = 9000

app.get('/', function (req, res, next) {
    res.send('Hello Hackathon!')
})

app.get('/bank/accounts', function (req, res, next) {
    bank.getAccounts((error, response, body) => {
        if (error) return console.error('Failed: %s', error.message)
        res.send(body)
    })
})

app.get('/bank/accounts/:account', function (req, res, next) {
    bank.getAccount(req.params.account, (error, response, body) => {
        if (error) return console.error('Failed: %s', error.message)
        res.send(body)
    })
})

app.get('/bank/accounts/:account/balance', function (req, res, next) {
    bank.getAccount(req.params.account, (error, response, body) => {
        if (error) return console.error('Failed: %s', error.message)
        res.send(body)
    }, true)
})

app.listen(port, () => console.log(`Your app is listening on port ${port}!`))