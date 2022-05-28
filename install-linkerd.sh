# create namespace
kubectl apply -f linkerd/namespaces/linkerd.yaml

# create deployments
kubectl apply -f linkerd/deployments/gateway-service.yaml
kubectl apply -f linkerd/deployments/validation-service.yaml
kubectl apply -f linkerd/deployments/netcore-accounts-service.yaml
kubectl apply -f linkerd/deployments/python-accounts-service.yaml

# create additional resources
kubectl apply -f linkerd/rules/autoscalling.yaml
kubectl apply -f linkerd/rules/security-rules.yaml
kubectl apply -f linkerd/rules/services.yaml
kubectl apply -f linkerd/rules/traffic-splitting.yaml