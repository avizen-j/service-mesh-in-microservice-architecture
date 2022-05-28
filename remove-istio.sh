# delete namespace
kubectl delete -f istio/namespaces/istio.yaml

# delete deployments
kubectl delete -f istio/deployments/gateway-service.yaml
kubectl delete -f istio/deployments/validation-service.yaml
kubectl delete -f istio/deployments/netcore-accounts-service.yaml
kubectl delete -f istio/deployments/python-accounts-service.yaml

# delete additional resources
kubectl delete -f istio/rules/autoscalling.yaml
kubectl delete -f istio/rules/security-rules.yaml
kubectl delete -f istio/rules/services.yaml
kubectl delete -f istio/rules/traffic-splitting.yaml