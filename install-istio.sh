# create namespace
kubectl apply -f istio/namespaces/istio.yaml

# enable sidecar auto injection
kubectl label namespace netcore-istio istio-injection=enabled

# create deployments
kubectl apply -f istio/deployments/gateway-service.yaml
kubectl apply -f istio/deployments/validation-service.yaml
kubectl apply -f istio/deployments/netcore-accounts-service.yaml
kubectl apply -f istio/deployments/python-accounts-service.yaml

# create additional resources
kubectl apply -f istio/rules/autoscalling.yaml
kubectl apply -f istio/rules/security-rules.yaml
kubectl apply -f istio/rules/services.yaml
kubectl apply -f istio/rules/traffic-splitting.yaml
