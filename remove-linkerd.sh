# delete namespace
kubectl delete -f linkerd/namespaces/linkerd.yaml

# delete deployments
kubectl delete -f linkerd/deployments/gateway-service.yaml
kubectl delete -f linkerd/deployments/validation-service.yaml
kubectl delete -f linkerd/deployments/netcore-accounts-service.yaml
kubectl delete -f linkerd/deployments/python-accounts-service.yaml

# delete additional resources
kubectl delete -f linkerd/rules/autoscalling.yaml
kubectl delete -f linkerd/rules/security-rules.yaml
kubectl delete -f linkerd/rules/services.yaml
kubectl delete -f linkerd/rules/traffic-splitting.yaml