const request = require('request')
const uuidv1 = require('uuid/v1')

const BASE_URL = 'https://sandbox.handelsbanken.com'

/**
 * Each request to Handelsbanken's API requires a couple 
 * of unique headers, so set them in this function
 * along with the (demo) authorization headers.
 */
const createHeaders = () => {
    return {
        accept: 'application/json',
        'tpp-request-id': uuidv1(),
        'tpp-transaction-id': uuidv1(),
        'psu-ip-address': '127.0.0.1',
        authorization: `Bearer ${process.env.HANDELSBANKEN_TOKEN}`,
        'x-ibm-client-id': process.env.HANDELSBANKEN_CLIENT_ID
    }
}

/**
 * Gets a list of a user's accounts. The user
 * is derived from the Bearer token.
 * 
 */
exports.getAccounts = (callback) => {
    const options = {
        method: 'GET',
        url: `${BASE_URL}/openbanking/psd2/v2/accounts`,
        headers: createHeaders()
    }
    request(options, callback)
}

/**
 * Gets information about an account.
 * 
 */
exports.getAccount = (id, callback, withBalance = false) => {
    const queryParams = {
        withBalance
    }
    const options = {
        method: 'GET',
        qs: queryParams,
        url: `${BASE_URL}/openbanking/psd2/v2/accounts/${id}`,
        headers: createHeaders()
    }
    request(options, callback)
}