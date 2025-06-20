
class Model:
    def __init__(self,model_name,architecture,frequency,ram):
        self.Name=model_name
        self.Architecture = architecture
        self.Frequency = frequency
        self.Ram = ram

    def __eq__(self, other):
        return (
            isinstance(other, Model) and
            self.Name == other.Name
        )
    def __hash__(self):
        return hash((self.Name, self.Architecture, self.Frequency))