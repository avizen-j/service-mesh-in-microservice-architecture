curl -X POST -H "Content-Type: application/json" \
    -d '{ "creditorId": "admin", "debtorId": "12888", "paymentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6", "receivedTimestamp": "2022-04-10T20:51:01.574Z", "validationServiceUri": "http://validation-service.netcore-linkerd.svc.cluster.local" }' \
    http://localhost:5010/incoming/new