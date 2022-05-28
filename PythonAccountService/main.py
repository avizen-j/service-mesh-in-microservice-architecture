import random
from flask import Flask
app = Flask(__name__)

@app.route("/accounts/<accountId>/summary")
def retrieveAccountSummary(accountId):
    accountsList = ["test", "admin", "pilot"]
    validAccount = any(creditor in accountId for creditor in accountsList)
    if (validAccount):
        response = {'accountId': accountId, 'amount': random.uniform(20, 1000), 'currency': 'DKK', 'version': 'python-accounts-service'}
        return response, 200
    
    return 404

if __name__ == "__main__":
    app.run(host='0.0.0.0', port=80)