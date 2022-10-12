// Copyright 2020-2022 Andreas Atteneder
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace GLTFast.Schema
{

    /// <summary>
    /// Base class for anything with a name property
    /// </summary>
    [System.Serializable]
    public abstract class NamedObject<TExtra> where TExtra : BaseExtras
    {

        /// <summary>
        /// Object's name
        /// </summary>
        public string name;

        public TExtra extras;

        internal void GltfSerializeRoot(JsonWriter writer)
        {
            if (!string.IsNullOrEmpty(name))
            {
                writer.AddProperty("name", name);
            }

            if(extras != null)
            {
                writer.AddProperty("extras");
                extras.GltfSerialize(writer);
            }
        }
    }

    [System.Serializable]
    public abstract class NamedObject : NamedObject<BaseExtras>
    {

    }

    [System.Serializable]
    public class BaseExtras
    {
        public string emk_identity;

        internal virtual void GltfSerialize(JsonWriter writer)
        {
            if (!string.IsNullOrEmpty(emk_identity))
            {
                writer.AddProperty("emk_identity", emk_identity);
            }
        }
    }
}
